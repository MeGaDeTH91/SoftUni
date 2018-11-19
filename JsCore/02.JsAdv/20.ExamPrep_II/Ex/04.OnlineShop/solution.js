function onlineShop(selector) {
    let form = `<div id="header">Online Shop Inventory</div>
    <div class="block">
        <label class="field">Product details:</label>
        <br>
        <input placeholder="Enter product" class="custom-select">
        <input class="input1" id="price" type="number" min="1" max="999999" value="1"><label class="text">BGN</label>
        <input class="input1" id="quantity" type="number" min="1" value="1"><label class="text">Qty.</label>
        <button id="submit" class="button" disabled>Submit</button>
        <br><br>
        <label class="field">Inventory:</label>
        <br>
        <ul class="display">
        </ul>
        <br>
        <label class="field">Capacity:</label><input id="capacity" readonly>
        <label class="field">(maximum capacity is 150 items.)</label>
        <br>
        <label class="field">Price:</label><input id="sum" readonly>
        <label class="field">BGN</label>
    </div>`;
    $(selector).html(form);

    let displayElement = $('.display');
    let productDetails = $('.custom-select');

    let totalPriceElement = $('#sum');
    let totalQuantityElement = $('#capacity');
    let totalPrice = +(totalPriceElement.val()) || 0;
    let totalQuantity = +(totalQuantityElement.val()) || 0;

    let submitButton = $('#submit');
    submitButton.on("click", function () {
        let priceField = +$('#price').val();
        let quantityField = +$('#quantity').val();
        debugger;
        if(totalQuantity + quantityField <= 150){
            displayElement.append($('<li>').text(`Product: ${productDetails.val()} Price: ${priceField} Quantity: ${quantityField}`));
            totalPrice += +priceField;
            totalQuantity += +quantityField;
            totalPriceElement.val(`${totalPrice}`);
            totalQuantityElement.val(`${totalQuantity}`);
        }
        if(totalQuantity === 150){
            totalQuantityElement.val('full');
            totalQuantityElement.addClass("fullCapacity");

            submitButton.attr("disabled", true);
            productDetails.attr("disabled", true);
            $('#price').attr("disabled", true);
            $('#quantity').attr("disabled", true);

        }
        resetAllFields();
    });

    productDetails.on("change", function () {
        if(productDetails.val()){
            submitButton.attr("disabled", false);
        } else{
            submitButton.attr("disabled", true);
        }
    });

    function resetAllFields(){
        $('#price').val('1');
        $('#quantity').val('1');
        productDetails.val('');
    }
}
