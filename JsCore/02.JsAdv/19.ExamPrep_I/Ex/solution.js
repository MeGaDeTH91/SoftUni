function makeReservation(containerId){
    //buttons
    let submitButton = $('#submit');
    let editButton = $('#edit');
    let continueButton = $('#continue');

    //the container
    let container = $(containerId);

    let fullNameField = $('#fullName');
    let emailField = $('#email');
    let phoneNumberField = $('#phoneNumber');
    let addressField = $('#address');
    let postalCodeField = $('#postalCode');

    let infoPreview = $('#infoPreview');

    submitButton.on("click", function () {
        let fullNameText = fullNameField.val();
        let emailText = emailField.val();
        let phoneNumberText = phoneNumberField.val();
        let addressText = addressField.val();
        let postalCodeText = postalCodeField.val();

        if(fullNameText.trim() !== "" && emailText.trim() !== ""){
            infoPreview.append($('<li>').text(`Name: ${fullNameText}`));
            infoPreview.append($('<li>').text(`E-mail: ${emailText}`));
            infoPreview.append($('<li>').text(`Phone: ${phoneNumberText}`));
            infoPreview.append($('<li>').text(`Address: ${addressText}`));
            infoPreview.append($('<li>').text(`Postal Code: ${postalCodeText}`));

            fullNameField.val("");
            emailField.val("");
            phoneNumberField.val("");
            addressField.val("");
            postalCodeField.val("");
            submitButton.attr("disabled", true);
            editButton.attr("disabled", false);
            continueButton.attr("disabled", false);
        }
    });
    editButton.on("click", function () {
        let information = infoPreview.children();

        fullNameField.val(information[0].textContent.substring(6));
        emailField.val(information[1].textContent.substring(8));
        phoneNumberField.val(information[2].textContent.substring(7));
        addressField.val(information[3].textContent.substring(9));
        postalCodeField.val(information[4].textContent.substring(13));

        infoPreview.empty();
        submitButton.attr("disabled", false);
        editButton.attr("disabled", true);
        continueButton.attr("disabled", true);
    });
    continueButton.on("click", function () {
        let extraDetailsDiv = $('<div>').attr("id", "extraDetails");
        let brElement = '<br>';
        let selectElement = $('<select>').attr('id', "paymentOptions").attr('class', 'custom-select');
        let defaultOption = $(`<option selected disabled hidden>Choose</option>`);
        let cardOption = $('<option>').val("creditCard").text("Credit Card");
        let bankOption = $('<option>').val("bankTransfer").text("Bank Transfer");
        selectElement.append(defaultOption);
        selectElement.append(cardOption);
        selectElement.append(bankOption);

        selectElement.on('change',function () {

            $('#extraDetails').empty();
            let checkOutButton = $('<button>').attr("id", "checkOut").text("Check Out");
            checkOutButton.on("click", function () {
               $('#wrapper').empty();
               $('#wrapper').append($('<h4>').text('Thank you for your reservation!'));
            });

            let selectedPaymentType = selectElement.val();

            if(selectedPaymentType === "creditCard"){
                let cardNumberDiv = $('<div>').attr("class", "inputLabel").text("Card Number").append($('<input>'));
                let expireDateDiv = $('<div>').attr("class", "inputLabel").text("Expiration Date").append($('<input>'));
                let securityNumberDiv = $('<div>').attr("class", "inputLabel").text("Security Numbers").append($('<input>'));

                extraDetailsDiv.append(cardNumberDiv).append(brElement).append(expireDateDiv).append(brElement).append(securityNumberDiv).append(brElement).append(checkOutButton);

            } else if(selectedPaymentType === "bankTransfer"){
                extraDetailsDiv.append($(`<p>You have 48 hours to transfer the amount to:<br>IBAN: GR96 0810 0010 0000 0123 4567 890</p>`)).append(checkOutButton);
            }
        });

        container.append($('<h2>').text("Payment details"));
        container.append(selectElement);
        container.append(extraDetailsDiv);

        submitButton.attr("disabled", true);
        editButton.attr("disabled", true);
        continueButton.attr("disabled", true);
    })
}