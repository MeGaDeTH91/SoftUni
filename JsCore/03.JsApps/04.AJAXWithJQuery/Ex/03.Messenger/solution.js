function attachEvents(){
    let firebaseURL = 'https://javascriptappsfirstdemo.firebaseio.com/messenger';

    let authorField = $('#author');
    let contentField = $('#content');

    let submitButton = $('#submit');
    let refreshButton = $('#refresh');

    submitButton.on("click", createMessage);
    refreshButton.on("click", loadMessages);

    function createMessage(){
        let newMessage = {
            author: authorField.val(),
            content: contentField.val(),
            timestamp: Date.now(),
        };

        $.post(firebaseURL + '.json', JSON.stringify(newMessage))
            .then(loadMessages());
    }

    function loadMessages(){
        $.get(firebaseURL + '.json')
            .then(displayMessages);
    }

    function displayMessages(messageResponse){
        $('#messages').empty();

        let sortedMessages = {};
        messageResponse = Object.keys(messageResponse).sort((a, b) => a.timestamp - b.timestamp).forEach(k => sortedMessages[k] = messageResponse[k]);

        for (const message of Object.keys(sortedMessages)) {
            $('#messages').append(`${sortedMessages[message]['author']}: ${sortedMessages[message]['content']}`)
        }
    }
}