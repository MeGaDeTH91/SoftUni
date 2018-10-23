function tickets(information, printInfo){
    //let arr = line.split("\n");

    //let information = arr[0];
    //let printInfo = arr[1];

    let namePattern = /(?<=\ )([A-Z][a-zA-Z]*\-[A-Z][a-zA-Z]*(\.\-[A-Z][a-zA-Z]*)*)(?=\ )/g;
    let airportPattern = /(?<=\ )([A-Z]{3}\/[A-Z]{3})(?=\ )/g;
    let flightNumberPattern = /(?<=\ )([A-Z]{1,3}[0-9]{1,5})(?=\ )/g;
    let companyPattern = /(?<=\-\ )([A-Z][a-zA-Z]*\*[A-Z][a-zA-Z]*)(?=\ )/g;

    if(printInfo === 'name'){
        let match = information.match(namePattern);

        if(match !== null){
            let name = match[0];
            name = name.replace(/\-/g, " ");
            console.log(`Mr/Ms, ${name}, have a nice flight!`);
        }
    }else if(printInfo === 'flight'){
        let matchAirports = information.match(airportPattern);
        let matchFlightNum = information.match(flightNumberPattern);

        if(matchAirports !== null && matchFlightNum !== null){
            let airports = matchAirports[0].split("/");
            let fromAirport = airports[0];
            let toAirport = airports[1];

            let flightNumber = matchFlightNum[0];

            console.log(`Your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}.`);
        }
    }else if(printInfo === 'company'){
        let companyMatch = information.match(companyPattern);

        if(companyMatch !== null){
            let company = companyMatch[0];
            company = company.replace(/\*/g, " ");

            console.log(`Have a nice flight with ${company}.`);
        }
    }else if(printInfo === 'all'){
        let nameMatch = information.match(namePattern);
        let matchAirports = information.match(airportPattern);
        let matchFlightNum = information.match(flightNumberPattern);
        let companyMatch = information.match(companyPattern);

        if(nameMatch !== null && matchAirports !== null &&
            matchFlightNum !== null && companyMatch !== null){
            let name = nameMatch[0];
            name = name.replace(/\-/g, " ");

            let airports = matchAirports[0].split("/");
            let fromAirport = airports[0];
            let toAirport = airports[1];

            let flightNumber = matchFlightNum[0];

            let company = companyMatch[0];
            company = company.replace(/\*/g, " ");

            console.log(`Mr/Ms, ${name}, your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}. Have a nice flight with ${company}.`);
        }


    }
}

tickets("ahah Second-Testov )*))&&ba SOF/VAR ela**  FB973  - Bulgaria*Air -op pa- SOF/VAr //_-  T12G12   STD08:45  STA09:35 \n" +
    "all");