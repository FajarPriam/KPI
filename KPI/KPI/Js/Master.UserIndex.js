$(document).ready(function () {
    
});

$("#tbl_users").DataTable({
    ajax: {
        url: $("#hd_path").val() + "getAllUser",
        type: "GET",
        datatype: "json",
        dataSrc: "data"
    },
    responsive: true,
    //order: [[2, 'desc']],
    columns: [
        {
            "mData": "User",
            "mRender": function (data, type, row) {
                return "<a href='#' onClick='openModal(" + data + ")'>EDIT</a>";
            }
        },
        { data: "USER", autoWidth: true },
        { data: "NAME", autoWidth: true },
        { data: "ROLE", autoWidth: true },
        { data: "POS_TITLE", autoWidth: true },
        { data: "DSTRCT_CODE", autoWidth: true }, 
    ],

    //columnDefs: [{ targets: 3, type: 'de_date' }],
});

function openModal(nrp) {
    console.log(nrp);
}