
function loading() {
    //console.log($("#governate").val());
    $.ajax({
        type: "GET",
        url: "/Home/getNeighborhood",
        data: { 'governorateID': $("#governate").val() },
        success: function (data) {
            console.log("data", data);
            renderUnit($('#NeighborhoodId'), data);
        },
        error: function (error) {
            console.log("err", error);
        }
    })
}

loading()