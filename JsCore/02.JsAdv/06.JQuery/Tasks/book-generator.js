function createBook(selector, bookTitle, bookAuthor, isbn) {
    (function (){
        let id = 1;

    return function (){
        let container = $(selector);

    let div = $('<div>');
    div.attr('id', `book${id++}`);
    div.css('border', 'none');
    
    let title = $('<p>');
    title.attr('class', 'title');
    title.text(bookTitle);
    div.append(title);

    let author = $('<p>');
    author.attr('class', 'author');
    author.text(bookAuthor);
    div.append(author);

    let isbnP = $('<p>');
    isbnP.attr('class', 'isbn');
    isbnP.text(isbn);
    div.append(isbnP);

    let selectButton = $('<button>Select</button>');
    selectButton.on('click', select);
    let deselectButton = $('<button>Deselect</button>');
    deselectButton.on('click', deselect);

    selectButton.appendTo(div);
    deselectButton.appendTo(div);

    div.appendTo(container);

    function select(){
        div.css('border', '2px solid blue')
    }
    function deselect(){
        div.css('border', 'none')
    }
        }
    })()();

    
}