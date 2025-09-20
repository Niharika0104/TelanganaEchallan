var table = document.getElementById('vehicleTable');
var modal = document.getElementById('menu2').getElementsByTagName('li')[10];
modal.addEventListener('click', function (e) {
    e.preventDefault();
    console.log("Hello")
})



function checking() {
    for (var i = 3; i < table.rows.length - 1; i++) {
        var selectAllCell = table.rows[i].cells[1];
        var cell = selectAllCell.getElementsByTagName('input')[0];
        cell.addEventListener('change', () => {
            console.log("cell")
            Change = true;
        })
        if (Change) break;
        if (selectAll.checked)
            cell.checked = true;
        else
            cell.checked = false;
    }
}
var selectAll = document.getElementById('selectAll')
var Change = false;
if (selectAll !== null) {
    selectAll.addEventListener('change', () => {
        if (table.rows.length > 0)
            checking();
    })
}
var panel = document.getElementById('Panel_vehicle_number');
console.log(panel + "panel")
/*if (Change) selectAll.checked = false;*/

console.log(selectAll)
let i = true;
var prm = Sys.WebForms.PageRequestManager.getInstance();


// Get a reference to the PageRequestManager
var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();

// Attach an event handler to the beginRequest event
pageRequestManager.add_endRequest(function (e) {
    console.log(e)
    modal = document.getElementById('menu2').getElementsByTagName('li')[10].getElementsByTagName('a')[0];
    console.log(modal.innerHTML)
    console.log(e._form)
    var v = e._form.getElementsByTagName('div')[9];

    console.log(v.id == "exampleModal")
    if (v.id == "exampleModal") {
        $('#exampleModal').modal('show')
    }



});

    




