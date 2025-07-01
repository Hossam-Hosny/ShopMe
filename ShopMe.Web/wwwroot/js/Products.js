var dtble;
$(document).ready(function () {
    loaddata()
});
function loaddata() {
    dtable = $("#mytable").DataTable({
        "ajax": {
            "url":"/Admin/Product/GetData"
        },
        "columns": [
            { "data": "name" },
            {"data":"description"},
            {"data":"price"},
            {"data":"category"}
        ]
    })
}