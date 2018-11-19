function tickets(args, sortingCriteria){
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = +price;
            this.status = status;
        }
    }

    let resultTickets = [];

    for (let i = 0; i < args.length; i++) {
        let ticketTokens = args[i].split("|");

        let destination = ticketTokens[0];
        let price = +ticketTokens[1];
        let status = ticketTokens[2];

        let currentTicket = new Ticket(destination, price, status);
        resultTickets.push(currentTicket);
    }

    resultTickets = resultTickets.sort((a, b) => a[sortingCriteria] > b[sortingCriteria]);

    return resultTickets;
}

tickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
);