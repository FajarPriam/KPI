$(document).ready(function () {

})

function uploadExcel() {
    if (window.FormData == undefined)
        alert("Error: FormData is undefined");

    else {
        var fileUpload = $("#fle_excel").get(0);
        var files = fileUpload.files;

        var fileData = new FormData();

        fileData.append(files[0].name, files[0]);

        $.ajax({
            url: "/Home/uploadFile",
            type: "post",
            datatype: "json",
            contentType: false,
            processData: false,
            async: false,
            data: fileData,
            success: function (response) {
                if (response.Status) {
                    console.log('oke');
                    console.log(response.Data);
                }
                else {
                    console.log(response.Remark);
                    alert(response.Remark);
                }
            }
        });
    }
}

function saveKPI(KPI) {
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: $("#hd_path").val() + "saveKPIs",
        success: function (result) {
            if (result.Status) {
                
            }
            else {
                
            }
        }
    })
}