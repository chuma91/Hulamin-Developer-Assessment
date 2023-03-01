function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode != 45 && charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

// removing a category from the list
function removeSupplier(Id) {

    $.ajax({
        type: 'POST',
        url: '/Suppliers/RemoveSupplier',
        data: {
            Id: Id
        },
        success: function (response) {
            if (response == true) {
                Swal.fire({
                    title: "Supplier Removed",
                    text: "Supplier Removed Successfully.",
                    icon: "success",
                    cancelButtonText: "Close",
                    cancelButtonColor: '#d33'
                }).then((result) => {
                    if (result.isConfirmed) {
                        var url = "/Suppliers/GetAllSuppliers";
                        window.location.href = url;
                    }
                });
            }
            else {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to remove supplier, please try again",
                    icon: 'error'
                })
            }

        },
        error: function (ex) {
            Swal.fire({
                title: "Failed",
                text: "Failed to remove supplier, please try again",
                icon: 'error'
            })
        }
    });
}


function UpdateSupplier(Id) {
    var valid = true;

    var CompanyName = document.getElementById("CompanyName").value;
    var ContactName = document.getElementById("ContactName").value;
    var ContactTitle = document.getElementById("ContactTitle").value;
    var Address = document.getElementById("Address").value;

    var City = document.getElementById("City").value;
    var Region = document.getElementById("Region").value;
    var PostalCode = document.getElementById("PostalCode").value;
    var Country = document.getElementById("Country").value;

    var Phone = document.getElementById("Phone").value;
    var Fax = document.getElementById("Fax").value;
    var HomePage = document.getElementById("HomePage").value;

    if (CompanyName == "") {
        iziToast.warning({
            title: 'Company Name Empty',
            message: 'Please Enter Company Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ContactName == "") {
        iziToast.warning({
            title: 'Contact Name Empty',
            message: 'Please Enter ContactName',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ContactTitle == "") {
        iziToast.warning({
            title: 'Contact Title Empty',
            message: 'Please Enter Contact Title',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Address == "") {
        iziToast.warning({
            title: 'Address Empty',
            message: 'Please Enter Address',
            position: 'topRight'
        });
        valid = false;
    }
    else if (City == "") {
        iziToast.warning({
            title: 'City Empty',
            message: 'Please Enter City',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Phone == "") {
        iziToast.warning({
            title: 'Phone Empty',
            message: 'Please Enter Phone',
            position: 'topRight'
        });
        valid = false;
    }

    var SupplierViewModel = {
        SupplierID: Id,
        CompanyName: CompanyName,
        ContactName: ContactName,
        ContactTitle: ContactTitle,
        Address: Address,
        City: City,
        Region: Region,
        PostalCode: PostalCode,
        Country: Country,
        Phone: Phone,
        Fax: Fax,
        HomePage: HomePage,
    };
    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Suppliers/EditSupplier',
            data: {
                SupplierViewModel: SupplierViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Supplier Updated",
                        text: "Supplier Updated Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Suppliers/GetAllSuppliers";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to update supplier, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to update supplier, please try again",
                    icon: 'error'
                })
            }
        });
    }

}


function AddSupplier() {
    var valid = true;


    var CompanyName = document.getElementById("CompanyName").value;
    var ContactName = document.getElementById("ContactName").value;
    var ContactTitle = document.getElementById("ContactTitle").value;
    var Address = document.getElementById("Address").value;

    var City = document.getElementById("City").value;
    var Region = document.getElementById("Region").value;
    var PostalCode = document.getElementById("PostalCode").value;
    var Country = document.getElementById("Country").value;

    var Phone = document.getElementById("Phone").value;
    var Fax = document.getElementById("Fax").value;
    var HomePage = document.getElementById("HomePage").value;

    if (CompanyName == "") {
        iziToast.warning({
            title: 'Company Name Empty',
            message: 'Please Enter Company Name',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ContactName == "") {
        iziToast.warning({
            title: 'Contact Name Empty',
            message: 'Please Enter ContactName',
            position: 'topRight'
        });
        valid = false;
    }
    else if (ContactTitle == "") {
        iziToast.warning({
            title: 'Contact Title Empty',
            message: 'Please Enter Contact Title',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Address == "") {
        iziToast.warning({
            title: 'Address Empty',
            message: 'Please Enter Address',
            position: 'topRight'
        });
        valid = false;
    }
    else if (City == "") {
        iziToast.warning({
            title: 'City Empty',
            message: 'Please Enter City',
            position: 'topRight'
        });
        valid = false;
    }
    else if (Phone == "") {
        iziToast.warning({
            title: 'Phone Empty',
            message: 'Please Enter Phone',
            position: 'topRight'
        });
        valid = false;
    }

    var SupplierViewModel = {
        CompanyName: CompanyName,
        ContactName: ContactName,
        ContactTitle: ContactTitle,
        Address: Address,
        City: City,
        Region: Region,
        PostalCode: PostalCode,
        Country: Country,
        Phone: Phone,
        Fax: Fax,
        HomePage: HomePage,
    };

    if (valid == true) {
        $.ajax({
            type: 'POST',
            url: '/Suppliers/AddSupplier',
            data: {
                SupplierViewModel: SupplierViewModel
            },
            success: function (response) {
                if (response == true) {
                    Swal.fire({
                        title: "Supplier Created",
                        text: "Supplier Creared Successfully.",
                        icon: "success",
                        cancelButtonText: "Close",
                        cancelButtonColor: '#d33'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            var url = "/Suppliers/GetAllSuppliers";
                            window.location.href = url;
                        }
                    });
                }
                else {
                    Swal.fire({
                        title: "Failed",
                        text: "Failed to create supplier, please try again",
                        icon: 'error'
                    })
                }

            },
            error: function (ex) {
                Swal.fire({
                    title: "Failed",
                    text: "Failed to create supplier, please try again",
                    icon: 'error'
                })
            }
        });
    }

}