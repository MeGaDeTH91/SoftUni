function getInfo() {
    let id = $('#stopId').val();
    let container = $('#stopName');
    let busList = $('#buses');

    $.get('https://judgetests.firebaseio.com/businfo/' + id + '.json')
        .then(displayResult)
        .catch(displayError);

    function displayResult(response){
        container.text(response['name']);
        for (let bus in response['buses']) {
            busList.append($('<li>').text(`Bus ${bus} arrives in ${response['buses'][bus]} minutes`))
        }
    }
    function displayError(error){
        container.text('Error');
    }
}