function addSticker(){
    let titleText = $('.title').val();
    let contentText = $('.content').val();

    if(titleText && contentText){
        let button = $(`<a class="button">x</a>`).on("click", removeItem);
        $('#sticker-list').append($(`<li class="note-content">`).append(button).append($(`<h2>${titleText}</h2>`)).append('<hr>').append(`<p>${contentText}</p>`));

        $('.title').val("");
        $('.content').val("");
    }
    function removeItem(){
        $(this).parent().remove();
    }
}