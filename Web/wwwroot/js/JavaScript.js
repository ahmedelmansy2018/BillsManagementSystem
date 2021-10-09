
var x;

    function AjaxPost(formData) {

        $.ajax({
            url: "https://localhost:44317/Home/CreateHDR",
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            dataType: "json",
            data: new FormData(formData),
            success: function (data) {
                var Table = $('#tbshow tbody');
                Table.empty();
                if (data.bilcod != undefined) {
                    x = data.bilcod;

                    console.log("OK");
                    $("#Div3").show();
                    $("#Div2").hide();
                    GetvendoerById(data.vndcod);
                    Table.append('<tr><td>' + data.bilcod + '</td><td>'
                        + data.bildat + '</td><td> ' + data.bilimg + '</td ><td>'
                        + data.bilprc + '</td><td id="vndcod">' + vndname + '</td></tr>');

                    $("#Div4").show();
                    GetAllItems();

                }
                else { toastr.error('NOT Vaild!'); }

            },
            error: function (err) {
                toastr.error('NOT Vaild!');

            }

        });

    return false;

    }
    function GetAllvendoers() {
        $.ajax({
            url: "https://localhost:44317/Home/GetAllVendors",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $.each(data, function (i, Vendor) {
                    $("#VNDCOD").append("  <option value=" + Vendor.vndcod + ">" + Vendor.vndnam + "</option>")
                    $("#VNDeCOD").append("  <option value=" + Vendor.vndcod + ">" + Vendor.vndnam + "</option>")

                });
            },
            error: function (err) {
                toastr.error('NOT Vaild!');
            }

        });
    }
    function GetAllItems() {
        $.ajax({
            url: "https://localhost:44317/Home/GetAllItems",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $.each(data, function (i, Item) {
                    $("#ITMCOD").append("  <option value=" + Item.itmcod + ">" + Item.itmnam + "</option>")
                    $("#ITMeCOD").append("  <option value=" + Item.itmcod + ">" + Item.itmnam + "</option>")
                });
            },
            error: function (err) {
               
            }

        });
    }
    function GetLastHeaderBill() {
        $.ajax({
            url: "https://localhost:44317/Home/GetLastHeaderBill",
            type: "GET",
            dataType: "json",
            success: function (data) {
                //  BILHDRCOd = data.bilcod;
                console.log("BILHDRCOd");

            },
            error: function (err) {
                alert(err);
            }

        });
    }
    var vndname;
    function GetvendoerById(id) {

        $.ajax({
            url: "https://localhost:44317/Home/GetvendoerById/" + id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#vndcod").val(data.vndnam);
                vndname = $("#vndcod").val();
                console.log(vndname);
                console.log(data);
            },
            error: function (err) {
                alert(err);
            }

        });
}
    
    var BillHeaderCod;
    function GetBilHeaderById(id)
    {
        GetAllvendoers();

        $("#BILeDAT").datepicker({

            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: "-10:+10"


        });
        BillHeaderCod = id
        $.ajax({
            url: "https://localhost:44317/Home/GetHeaderBillByid/" + id,
            type: "GET",
            dataType: "json",
            success: function (data) {
                console.log("000000");
                console.log(data);
                
                $("#BILCOD").val(data.bilcod);
                $("#BILeDAT").val(data.bildat);
                $("#VNDeCOD").val(data.vndcod);
                
                

            },
            error: function (err) {
                alert(err);
            }

        });
    }
    var BillDetailsCod;
    function GetBilDetailsById(id) {
        BillDetailsCod = id;
        $.ajax({
            url: "https://localhost:44317/Home/GetBilDetailsById/" + id,
            type: "GET",
            dataType: "json",
            success: function (data) {
               
                $("#ITMeQTY").val(data.itmqty);
                $("#ITMePRC").val(data.itmprc);
                $("#ITMeCOD").val(data.itmcod);



            },
            error: function (err) {
                alert(err);
            }

        });
    }
    function GetAllBillDetails(id) {
        $.ajax({
            url: "https://localhost:44317/Home/GetAllBillDetails/" + id,
            type: "GET",
            dataType: "json",
            success: function (data) {

                console.log(data);
                var tbDetailsTable = $('#tbDetails tbody');
                tbDetailsTable.empty();
                let TotalPriceBill = 0;
                $(data).each(function (index, data) {
                    console.log(data);
                    tbDetailsTable.append('<tr><td>' + data.itmnam + '</td><td>'
                        + data.itmprc + '</td><td>' + data.itmqty + '</td><td>'
                        + (data.itmprc * data.itmqty) + '</td><td> <button id=' + data.dtlcod + ' onClick="GetBilDetailsById(id)" class="btn btn-outline-dark" data-toggle="modal" data-target="#exampleModal" >Edit</button> </td > ' +
                        '<td><button  data-model-id=' + data.dtlcod + ' onClick="DeleteBilDeltials(this)" class="btn btn-danger">delete</button> </td></tr >');
                    TotalPriceBill +=  (data.itmprc * data.itmqty);
                });

                $.ajax({
                    url: "https://localhost:44317/Home/UPdatePrice",
                    type: "POST",
                    data: {
                       
                        BILCOD: x,
                        BILPRC: TotalPriceBill,
                    },
                    dataType: "json",
                    success: function (data) {
                        
                        console.log("succseedVVVVVVVddd");
                    },
                    error: function (err) {
                        console.log("xxxsxsxsx");
                    }

                });
                
            },


            error: function (err) {
                alert(err);
            }

        });
    }

function AjaxPostedit(formData) {

    $.ajax({
        url: "https://localhost:44317/Home/EditHDR",
        type: "POST",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        dataType: "json",
        data: new FormData(formData),
        success: function (data) {
            console.log(data);
            window.location.href = "https://localhost:44317/Home";
        },
        error: function (err) {
            console.log(err);

        }

    });

    return false;

}
function DeleteBilDeltials(obj) {
        var ele = $(obj);
    var id = ele.data("model-id");
    var url = "https://localhost:44317/Home/DeleteBilDeltials/" + id;
    swal({
        title: "Are you sure?",
    text: "You will Deleted this Bill !",
    icon: "warning",
    buttons: [
    'No, cancel it!',
    'Yes, I am sure!'
    ],
    dangerMode: true,
        }).then(function (isConfirm) {
            if (isConfirm) {
        swal({
            title: 'Deleted!',
            text: '  successfully Deleted!',
            icon: 'success'

        }).then(function () {


            $.ajax({
                url: url,
                type: "post",
                success: function () {

                    { ele.closest("tr").remove(); toastr.success('Deleted!'); }

                },
                error: function () { toastr.error('Failed!'); }

            });

        });
            } else {
        swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });




    }
    function Delete(obj) {
        var ele = $(obj);
    var id = ele.data("model-id");
    var url = "https://localhost:44317/Home/DeleteConfirmedJson/" + id;
    swal({
        title: "Are you sure?",
    text: "You will Deleted this Bill !",
    icon: "warning",
    buttons: [
    'No, cancel it!',
    'Yes, I am sure!'
    ],
    dangerMode: true,
        }).then(function (isConfirm) {
            if (isConfirm) {
        swal({
            title: 'Deleted!',
            text: '  successfully Deleted!',
            icon: 'success'

        }).then(function () {


            $.ajax({
                url: url,
                type: "post",
                success: function () {

                    { ele.closest("tr").remove(); toastr.success('Deleted!'); }

                },
                error: function () { toastr.error('Failed!'); }

            });

        });
            } else {
        swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });




}


 

function isPricevalide() {

    return ItemPrice.value.match(/^[0-9]{1,9}$/);
}
function isQTYvalide() {
    return itenQty.value.match(/^[0-9]{1,9}$/);
}




function isDatavalide() {
    var pattern = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;
   
    return BILDAT.value.match(pattern);
}
function isvendorvalide() {
    return VNDCOD.value.match(/^[0-9]$/);
}


    $(document).ready(function () {

        var ItemPrice = document.getElementById('ITMPRC');
        var itenQty = document.getElementById('ITMQTY');

        var BILDAT = document.getElementById('BILDAT');
        var VNDCOD = document.getElementById('VNDCOD');

        BILDAT.focus();

        // all spans
        var Dataerror = document.getElementById('Dataerror');
        var vendererror = document.getElementById('vendererror');
        ITMPRCerror = document.getElementById('ITMPRCerror');
        ITMQTYerror = document.getElementById('ITMQTYerror');

        
        $("#BILDAT").blur(function () {
            if (!isDatavalide()) {

                BILDAT.focus();
                BILDAT.select();
                Dataerror.style.display = 'block';
                BILDAT.classList.add("error");
            } else {
                Dataerror.style.display = 'none';
                BILDAT.classList.remove("error");
            }

        });// end of  test

        $("#VNDCOD").blur(function () {

            if (!isvendorvalide()) {

                VNDCOD.focus();
                VNDCOD.select();
                vendererror.style.display = 'block';
                VNDCOD.classList.add("error");
            } else {
                vendererror.style.display = 'none';
                VNDCOD.classList.remove("error");
            }
        });// 

        $("#AddBill").submit(function (data) {
            if (!(isDatavalide() && isvendorvalide())) {

                if (!isDatavalide()) {
                    Dataerror.style.display = 'block';
                    BILDAT.classList.add("error");

                }
                if (!isvendorvalide()) {
                    vendererror.style.display = 'block';
                    VNDCOD.classList.add("error");

                }
                data.preventDefault();

            }

        });







    $("#Div2").hide();
    $("#Div3").hide();
    $("#Div4").hide();


    $("#btnCreate").click(function () {
        
    $("#Div1").hide();
    $("#Div2").show();
    $("#Div4").hide();
    $("#BILDAT").datepicker({

        dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true,
    yearRange: "-10:+10"


    });
    GetAllvendoers();


        }); //end of btnCreate click

    $("#btnAddDetailsBill").click(function () {
        //  GetLastHeaderBill();
        console.log(x);
    var itemPrice = $("#ITMPRC").val();
    var itemQTY = $("#ITMQTY").val();
    var ITMCOD = $("#ITMCOD").val();

    $.ajax({
        url: "https://localhost:44317/Home/IsNameItemsAvailable",
    type: "POST",

    data: {
        HIDCODe: x,
    ITMe: ITMCOD
                },
    dataType: "json",
    success: function (data) {
        console.log("SAAAAaaaaaaaaa");
        if (data) {

        $.ajax({
            url: "https://localhost:44317/Home/CreateBillDetials",
            type: "POST",
            data: {
              //   dtlcod:5,
                ITMPRC: itemPrice,
                ITMQTY: itemQTY,
                BILCOD: x,
                ITMCOD: ITMCOD
            },
            dataType: "json",
            success: function (data) {
                GetAllBillDetails(x);
                console.log("succseed")
            },
            error: function (err) {

            }

        });
                    }
    else {toastr.error('ITems is already exists!'); }
    console.log(data);
                },
    error: function (err) {

    }

            });

        });//end of btnAddDetailsBill click

    $("#BtnEdit").click(function () {
            //  GetLastHeaderBill();
            //console.log(x);
    var itemPrice = $("#ITMePRC").val();
    var itemQTY = $("#ITMeQTY").val();
    var ITMCOD = $("#ITMeCOD").val();
    $.ajax({
        url: "https://localhost:44317/Home/IsNameItemsAvailable",
    type: "POST",

    data: {
        HIDCODe: x,
    ITMe: ITMCOD
                },
    dataType: "json",
    success: function (data) {
                    if (!data) {
        $.ajax({
            url: "https://localhost:44317/Home/EditBillDetials",
            type: "POST",
            data: {
                DTLCOD: BillDetailsCod,
                ITMPRC: itemPrice,
                ITMQTY: itemQTY,
                BILCOD: x,
                ITMCOD: ITMCOD
            },
            dataType: "json",
            success: function (data) {
                GetAllBillDetails(x);
                toastr.success('Edit succseed!');

                console.log("succseed")


            },
            error: function (err) {
                toastr.error('Edit Fialed!');
            }

        });

                    }
    else {toastr.error('ITems is NoT Vaild!'); }
    console.log(data);
                },
    error: function (err) {

    }

            });


          

        });//end of BtnEdit click

    console.log("ready!");
    });

