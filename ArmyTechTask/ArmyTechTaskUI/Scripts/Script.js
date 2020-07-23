$(document).ready(function () {
    $("#governate").on("change", function () {
        console.log($(this).val())
        $.ajax({
            type: "GET",
            url: "/Home/getNeighborhood",
            data: { 'governorateID': $(this).val() },
            success: function (data) {
                console.log("data", data);
                renderUnit($('#NeighborhoodId'), data);
            },
            error: function (error) {
                console.log("err", error);
            }
        })
        
    })
    
})

function renderUnit(unit, data) {
    var $unit = $(unit);
    $unit.empty();
    var sel = document.getElementById('NeighborhoodId');
    var opt = document.createElement('option');
    opt.appendChild(document.createTextNode("Select"));
    opt.value = 0;
    sel.appendChild(opt);
    $.each(data, function (i, val) {
        var opt = document.createElement('option');
        opt.appendChild(document.createTextNode(val.Name));
        opt.value = val.ID;
        sel.appendChild(opt);

    })
}
function loadNeighborhood(temp)
{

}