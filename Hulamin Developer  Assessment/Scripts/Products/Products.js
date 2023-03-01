function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKeyDecimal(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode == 46) {
        var inputValue = $("#inputfield").val()
        if (inputValue.indexOf('.') < 1) {
            return true;
        }
        return false;
    }
    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

// removing a category from the list
function removeProduct(Id) {

    $.ajax({
        type: 'POST',
        url: '/Products/RemoveProduct',
        data: {
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Product Removed",
                    text: "Product Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Products/GetAllProducts";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove product, please try again",
                    icon: 'error'
                })
            }

        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove product, please try again",
                icon: 'error'
            })
        }
    });
}


function UpdateProduct(Id) {
    var valid = true;
    var Discontinued = false;

    var ProductName = document.getElementById("ProductName").value;
    var QuantityPerUnit = document.getElementById("QuantityPerUnit").value;
    var UnitPrice = document.getElementById("UnitPrice").value;
    var UnitsInStock = document.getElementById("UnitsInStock").value;

    var UnitsOnOrder = document.getElementById("UnitsOnOrder").value;
    var ReorderLevel = document.getElementById("ReorderLevel").value;

    if (document.getElementById('DiscontinuedTrue').checked) {
        Discontinued = document.getElementById('DiscontinuedTrue').value;
    }
    else {
        Discontinued = document.getElementById("DiscontinuedFalse").value;
    }

    if (ProductName == "") {
        iziToast.warning({
            title: 'Product Name Empty',
            message: 'Please Enter Product Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (QuantityPerUnit == "") {
        iziToast.warning({
            title: 'QuantityPerUnit Empty',
            message: 'Please Enter QuantityPerUnit',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitPrice == "") {
        iziToast.warning({
            title: 'UnitPrice Empty',
            message: 'Please Enter UnitPrice',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitsInStock == "") {
        iziToast.warning({
            title: 'UnitsInStock Empty',
            message: 'Please Enter UnitsInStock',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitsOnOrder == "") {
        iziToast.warning({
            title: 'UnitsOnOrder Empty',
            message: 'Please Enter UnitsOnOrder',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ReorderLevel == "") {
        iziToast.warning({
            title: 'ReorderLevel Empty',
            message: 'Please Enter ReorderLevel',
            position: 'topRight'
        });
        valid = false;
    }

    var ProductsViewModel = {
        ProductID: Id,
        ProductName: ProductName,
        QuantityPerUnit: QuantityPerUnit,
        UnitPrice: UnitPrice,
        UnitInStock: UnitsInStock,
        UnitOnOrder: UnitsOnOrder,
        ReorderLevel: ReorderLevel,
        Discontinued: Discontinued,
    };
    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Products/EditProduct',
            data: {
                ProductsViewModel: ProductsViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Product Updated",
                        text: "Product Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Products/GetAllProducts";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update product, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update product, please try again",
                    icon: 'error'
                })
            }
        });
    }

}


function AddProduct() {
    var valid = true;

    var Discontinued = false;

    var ProductName = document.getElementById("ProductName").value;
    var SuppliersID = document.getElementById("SupplierID").value;
    var CategoryID = document.getElementById("CategoryID").value;
    var QuantityPerUnit = document.getElementById("QuantityPerUnit").value;
    var UnitPrice = document.getElementById("UnitPrice").value;
    var UnitsInStock = document.getElementById("UnitsInStock").value;

    var UnitsOnOrder = document.getElementById("UnitsOnOrder").value;
    var ReorderLevel = document.getElementById("ReorderLevel").value;

    if (document.getElementById('DiscontinuedTrue').checked) {
        Discontinued = document.getElementById('DiscontinuedTrue').value;
    }
    else {
        Discontinued = document.getElementById("DiscontinuedFalse").value;
    }

    if (ProductName == "") {
        iziToast.warning({
            title: 'Product Name Empty',
            message: 'Please Enter Product Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if ($("#SupplierID").find(':selected').text() == "Select Supplier") {
        iziToast.warning({
            title: 'Warning!',
            message: 'Please Select Supplier !',
            position: 'topRight'
        });
        return false;
    }
    else if ($("#CategoryID").find(':selected').text() == "Select Category") {
        iziToast.warning({
            title: 'Warning!',
            message: 'Please Select Category !',
            position: 'topRight'
        });
        return false;
    }
    else if (QuantityPerUnit == "") {
        iziToast.warning({
            title: 'QuantityPerUnit Empty',
            message: 'Please Enter QuantityPerUnit',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitPrice == "") {
        iziToast.warning({
            title: 'UnitPrice Empty',
            message: 'Please Enter UnitPrice',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitsInStock == "") {
        iziToast.warning({
            title: 'UnitsInStock Empty',
            message: 'Please Enter UnitsInStock',
            position: 'topRight'
        });
        valid = false;
    }
    else if (UnitsOnOrder == "") {
        iziToast.warning({
            title: 'UnitsOnOrder Empty',
            message: 'Please Enter UnitsOnOrder',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ReorderLevel == "") {
        iziToast.warning({
            title: 'ReorderLevel Empty',
            message: 'Please Enter ReorderLevel',
            position: 'topRight'
        });
        valid = false;
    }

    var ProductsViewModel = {
        SuppliersID: SuppliersID,
        CategoryID: CategoryID,
        ProductName: ProductName,
        QuantityPerUnit: QuantityPerUnit,
        UnitPrice: UnitPrice,
        UnitInStock: UnitsInStock,
        UnitOnOrder: UnitsOnOrder,
        ReorderLevel: ReorderLevel,
        Discontinued: Discontinued,
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Products/AddProduct',
            data: {
                ProductsViewModel: ProductsViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Product Created",
                        text: "Product Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Products/GetAllProducts";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create product, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create product, please try again",
                    icon: 'error'
                })
            }
        });
    }

}