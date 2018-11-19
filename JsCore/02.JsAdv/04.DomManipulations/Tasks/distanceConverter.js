function attachEventsListeners() {
    document.getElementById("convert").addEventListener("click", calculate);
    
    function calculate(){
        let inputUnits = document.getElementById("inputUnits").value;
        let outputUnits = document.getElementById("outputUnits").value;
    
        let inputDistanceInMeters = +document.getElementById("inputDistance").value;

        switch(inputUnits){
            case"km": inputDistanceInMeters *= 1000;
            break;
            case"cm": inputDistanceInMeters *= 0.01;
            break;
            case"mm": inputDistanceInMeters *= 0.001;
            break;
            case"mi": inputDistanceInMeters *= 1609.34;
            break;
            case"yrd": inputDistanceInMeters *= 0.9144;
            break;
            case"ft": inputDistanceInMeters *= 0.3048;
            break;
            case"in": inputDistanceInMeters *= 0.0254;
            break;
        }

        switch(outputUnits){
            case"km": inputDistanceInMeters /= 1000;
            break;
            case"cm": inputDistanceInMeters /= 0.01;
            break;
            case"mm": inputDistanceInMeters /= 0.001;
            break;
            case"mi": inputDistanceInMeters /= 1609.34;
            break;
            case"yrd": inputDistanceInMeters /= 0.9144;
            break;
            case"ft": inputDistanceInMeters /= 0.3048;
            break;
            case"in": inputDistanceInMeters /= 0.0254;
            break;
        }

        document.getElementById("outputDistance").value = inputDistanceInMeters;
    }
}