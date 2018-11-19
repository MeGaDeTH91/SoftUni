function addDestination (){
    let city = $('.inputData')[0].value;
    let country = $('.inputData')[1].value;

    let season = $('#seasons').val();
    let seasonText = $('#seasons option:selected').text();
    if(city && country && season){
        let row = $('<tr>');
        row.append($('<td>').text(`${city}, ${country}`));
        row.append($('<td>').text(seasonText));
        $('#destinationsList').append(row);

        $('.inputData')[0].value = "";
        $('.inputData')[1].value = "";

        let seasonValue = $(`#${season}`).val();

        $(`#${season}`).val(+seasonValue + 1);
    }
}