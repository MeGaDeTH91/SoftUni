function attachEvents(){
    const baseKinveyUrl = `https://baas.kinvey.com/appdata/kid_rkYGcNnk4/biggestCatches`;
    const base64Auth = btoa(`guest:guest`);
    const authHeaders = {"Authorization":"Basic " + base64Auth};

    debugger;
    $('.load').on('click',loadCatches);
    $('.add').on('click', addCatch);

    function loadCatches(){
        $('#catches').empty();

        $.ajax({
            url:baseKinveyUrl,
            method: "GET",
            headers: authHeaders
        }).then(displayCatches);

        function displayCatches(response){

            debugger;
            for(let catche of response){
                $('#catches')
                    .append($('<div>').addClass("catch").attr("data-id", catche._id)
                        .append($('<label>').text("Angler"))
                        .append($('<input>').attr("type", "text").addClass("angler").val(catche.angler))
                        .append($('<label>').text("Weight"))
                        .append($('<input>').attr("type", "number").addClass("weight").val(catche.weight))
                        .append($('<label>').text("Species"))
                        .append($('<input>').attr("type", "text").addClass("species").val(catche.species))
                        .append($('<label>').text("Location"))
                        .append($('<input>').attr("type", "text").addClass("location").val(catche.location))
                        .append($('<label>').text("Bait"))
                        .append($('<input>').attr("type", "text").addClass("bait").val(catche.bait))
                        .append($('<label>').text("Capture Time"))
                        .append($('<input>').attr("type", "number").addClass("captureTime").val(catche.captureTime))
                        .append($('<button>').addClass("update").text("Update").click(updateCatch))
                        .append($('<button>').addClass("delete").text("Delete").click(deleteCatch))
                    );
            }
        }
    }
    
    function addCatch() {
        let inputs = $(this).parent().find('input');

        let request = {
            url:baseKinveyUrl,
            method: "POST",
            headers: {"Authorization":"Basic " +base64Auth, "Content-type": "application/json"},
            data: JSON.stringify({
                angler:$(inputs[0]).val(),
                weight:Number($(inputs[1]).val()),
                species:$(inputs[2]).val(),
                location:$(inputs[3]).val(),
                bait:$(inputs[4]).val(),
                captureTime:Number($(inputs[5]).val())
            })
        };
        debugger;
        $.ajax(request)
            .then(loadCatches);

        for(let input of inputs){
            $(input).val('');
        }
    }
    
    function updateCatch(){
        let inputs = $(this).parent().find('input');
        let catchId = $(this).parent().attr('data-id');

        let request = {
            url:baseKinveyUrl + `/${catchId}`,
            method: "PUT",
            headers: {"Authorization":"Basic " +base64Auth, "Content-type": "application/json"},
            data: JSON.stringify({
                angler:$(inputs[0]).val(),
                weight:Number($(inputs[1]).val()),
                species:$(inputs[2]).val(),
                location:$(inputs[3]).val(),
                bait:$(inputs[4]).val(),
                captureTime:Number($(inputs[5]).val())
            })
        };

        $.ajax(request)
            .then(loadCatches);
    }
    
    function deleteCatch() {
        let catchId = $(this).parent().attr('data-id');

        let request = {
            url:baseKinveyUrl + `/${catchId}`,
            method: "DELETE",
            headers: {"Authorization":"Basic " +base64Auth, "Content-type": "application/json"},
        };

        $.ajax(request)
            .then(loadCatches);
    }
}