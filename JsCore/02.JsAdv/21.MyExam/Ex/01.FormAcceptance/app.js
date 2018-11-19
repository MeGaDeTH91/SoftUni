function acceptance() {

    let inputFields = $('#fields ').children();

    let companyNameInput = inputFields[0].valueOf().childNodes[0].value;
    let productNameInput = inputFields[1].valueOf().childNodes[0].value;
    let productQuantityInput = +inputFields[2].valueOf().childNodes[0].value;
    let productScrapeInput = +inputFields[3].valueOf().childNodes[0].value;

    if(companyNameInput && productNameInput && !isNaN(productQuantityInput) && !isNaN(productScrapeInput)){

        let difference = productQuantityInput - productScrapeInput;

        if(difference > 0){
            let warehouse = $('#warehouse');

            let div = $('<div>');
            let paragraph = $('<p>').text(`[${companyNameInput}] ${productNameInput} - ${difference} pieces`);
            let button = $('<button>').attr("type", "button").text("Out of stock");
            button.on("click", removeItem);

            div.append(paragraph);
            div.append(button);
            warehouse.append(div);
        }

        inputFields[0].valueOf().childNodes[0].value = "";
        inputFields[1].valueOf().childNodes[0].value = "";
        inputFields[2].valueOf().childNodes[0].value = "";
        inputFields[3].valueOf().childNodes[0].value = "";
    }
    function removeItem(){
        $(this).parent().remove();
    }
}