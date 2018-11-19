function domSearch(selector, isItCaseSensitive) {
    let container = $(selector);
    let addControlsDiv = $('<div>');
    addControlsDiv.attr('class', 'add-controls');
    addControlsDiv.append($('<label>').text("Enter text: ").append('<input>'));

    let addButton = $('<a>');
    addButton.attr('class', 'button');
    addButton.text('Add');
    addButton.on('click', addItem);
    addControlsDiv.append(addButton);
    container.append(addControlsDiv);

    let searchControlsDiv = $('<div>');
    searchControlsDiv.addClass('search-controls');
    searchControlsDiv.append($('<label>').text("Search:").append($('<input>').on('input', search)));
    container.append(searchControlsDiv);

    let resultControlsDiv = $('<div>');
    resultControlsDiv.addClass('result-controls');
    let ulResults = $('<ul>');
    ulResults.addClass('items-list');
    resultControlsDiv.append(ulResults);
    container.append(resultControlsDiv);

    function addItem() {
        let text = $('.add-controls label input').val();
        $('.items-list').append($('<li>').addClass('list-item').append($('<a>').addClass('button').text('X').on('click', removeItem)).append($('<strong>').text(text)));
        $('.add-controls label input').val("");
    }
    function removeItem(){
        $(this).parent().remove();
    }
    function search(){
        let text = $(this).val();

        $('.list-item').each((index, li) => matches(li, text));
    }

    function matches(li, text){
        
        if(isItCaseSensitive){
            if($(li).find('strong').text().indexOf(text) == -1){
                $(li).css('display', 'none');
            }
        } else{
            if($(li).find('strong').text().toLowerCase().indexOf(text.toLowerCase()) == -1){
                $(li).css('display', 'none');
            }
        }
    }
}