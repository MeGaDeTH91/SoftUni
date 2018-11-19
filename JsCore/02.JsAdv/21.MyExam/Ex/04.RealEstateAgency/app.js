function realEstateAgency () {
	let regButton = $('button[name=regOffer]');
	regButton.on("click", function () {
        let rentPrice = +$('input[name=apartmentRent]').val();
        let apartmentType = $('input[name=apartmentType]').val();
        let comissionRate = +$('input[name=agencyCommission]').val();


        if(isNaN(rentPrice) || !apartmentType || isNaN(comissionRate) || rentPrice <= 0 || comissionRate < 0 || comissionRate > 100 || apartmentType.indexOf(':') > -1){
            $('#message').text(`Your offer registration went wrong, try again.`);
        } else{
            let buildingDiv = $('#building');
            let apartmentDiv = $('<div>').attr("class", "apartment");

            let rentParagraph = $('<p>').text(`Rent: ${rentPrice}`);
            let typeParagraph = $('<p>').text(`Type: ${apartmentType}`);
            let commissionParagraph = $('<p>').text(`Commission: ${comissionRate}`);

            apartmentDiv.append(rentParagraph).append(typeParagraph).append(commissionParagraph);

            buildingDiv.append(apartmentDiv);

            $('#message').text(`Your offer was created successfully.`);
        }

        $('input[name=apartmentRent]').val("");
        $('input[name=apartmentType]').val("");
        $('input[name=agencyCommission]').val("");
    });

    let findButton = $('button[name=findOffer]');
    findButton.on("click", function () {
        let familyBudget = +$('input[name=familyBudget]').val();
        let apartmentType = $('input[name=familyApartmentType]').val();
        let familyName = $('input[name=familyName]').val();

        let apartmentsCount = $('#building').children().length;

        let homeIsFound = false;

        if(isNaN(familyBudget) || !apartmentType || !familyName || familyBudget <= 0 || apartmentsCount === 0){
            $('#message').text(`We were unable to find you a home, so sorry :(`);
        } else{
            let buildingDiv = $('#building').children();
            for (let i = 0; i < buildingDiv.length; i++) {
                let apartmentDiv = buildingDiv[i];

                let neededRent = +apartmentDiv.childNodes[0].textContent.substring(6);
                let searchedApartmentType = apartmentDiv.childNodes[1].textContent.substring(6);
                let neededCommission = +apartmentDiv.childNodes[2].textContent.substring(12);

                if(apartmentType === searchedApartmentType){
                    let commissionSum = (neededRent * (neededCommission / 100));
                    let neededMoney = neededRent + commissionSum;

                    debugger;
                    if(familyBudget < neededMoney){
                        $('#message').text(`We were unable to find you a home, so sorry :(`);
                    } else{
                        homeIsFound = true;
                        let roofElement = $('#roof');
                        let totalIncomeStr = roofElement.children()[0].textContent.substring(15);
                        totalIncomeStr = totalIncomeStr.substring(0, totalIncomeStr.length - 3).trim();

                        let totalIncome = +totalIncomeStr + (2 * commissionSum);

                        let divToChange = $(apartmentDiv).empty();

                        divToChange.attr("style", "border: 2px solid red;");
                        let familyParagraph = $('<p>').text(`${familyName}`);
                        let liveHereNow = $('<p>').text(`live here now`);

                        let moveOutButton = $('<button>').text('MoveOut');
                        moveOutButton.on("click", removeItem);

                        divToChange.append(familyParagraph).append(liveHereNow).append(moveOutButton);

                        roofElement.children()[0].textContent = `Agency profit: ${totalIncome} lv.`;

                        $('#message').text(`Enjoy your new home! :))`);

                    }
                }
            }
            if(!homeIsFound){
                $('#message').text(`We were unable to find you a home, so sorry :(`);
            }
        }


        $('input[name=familyBudget]').val("");
        $('input[name=familyApartmentType]').val("");
        $('input[name=familyName]').val("");
    });
    function removeItem(){
        let familyName = $(this).parent()[0].childNodes[0].textContent;
        $(this).parent().remove();

        $('#message').text(`They had found cockroaches in ${familyName}'s apartment`);
    }
}