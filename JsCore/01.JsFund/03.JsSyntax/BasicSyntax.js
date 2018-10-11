// 1.Hello, JavaScript!
function solve(name){
    console.log("Hello, " + name + ", I am JavaScript!");
}

// 2.Area and Perimeter
function areaAndPerimeter(a, b){
    let area = a * b;
    let perimeter = (2 * a) + (2 * b);
    console.log(area);
    console.log(perimeter);
}

// 3.Distance over Time
function distance(arr){
    let v1 = arr[0];
    let v2 = arr[1];
    let t = arr[2];
    let v1InMeters = (1000/3600) * v1;
    let v2InMeters = (1000/3600) * v2;

    let distance1 = v1InMeters * t;
    let distance2 = v2InMeters * t;

    let diff = Math.abs(distance1 - distance2);

    console.log(diff); 
}

// 04.Distance in 3D  - FIX
function distanceInThreeD(arr){
    let x1 = +arr[0];
    let y1 = +arr[1];
    let z1 = +arr[2];

    let x2 = +arr[3];
    let y2 = +arr[4];
    let z2 = +arr[5];

    let dx = x1 - x2;
    let dy = y1 - y2;
    let dz = z1 - z2;

    let dist = Math.sqrt(Math.pow(dx, 2) + Math.pow(dy, 2) + Math.pow(dz, 2));

    console.log(dist);
}

// 05. Grads to Degrees
function gradToDegrees(grad){
    let rawDeg = 0.9 * grad;
    let degrees = rawDeg % 360;
    if(grad >= 0){
        console.log(degrees);
    }else{
        degrees = 360 - Math.abs(degrees);
        console.log(degrees);
    }
}

// 06. Compound Interest
function compInterest(arr){
    let principalSum = arr[0];
    let interestPercentRate = arr[1] / 100;
    let compoundPeriodMonths = arr[2];
    let totalTimespanYears = arr[3];

    let frequency = 12 / compoundPeriodMonths;

    let result = principalSum * Math.pow((1 + interestPercentRate / frequency), frequency * totalTimespanYears);

    console.log(result);
}

// 07. Rounding
function precision(arr){
    let number = parseFloat(arr[0]);
    let precision = arr[1];
    if(precision > 15){
        precision = 15;
    }

    number = (Number)(number.toFixed(precision));

    console.log(number);
}

// 08. Imperial Units
function imperials(number){
    let feet = Math.floor(number / 12);
    let inches = number % 12;

    console.log(`${feet}'-${inches}"`);
}

// 09. Now playing
function playing(arr){
    let trackName = arr[0];
    let artistName = arr[1];
    let duration = arr[2];

    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

// 10. Compose Tag
function tag(arr){
    let location = arr[0];
    let altText = arr[1];

    console.log(`<img src="${location}" alt="${altText}">`);
}

// 11. Binary To Decimal
function binaryToDec(binary){
    let number = parseInt(binary, 2);

    console.log(number);
}

// 12. Assign Properties
function properties(arr){
    let el1 = arr[0];
    let el2 = arr[1];
    let el3 = arr[2];
    let el4 = arr[3];
    let el5 = arr[4];
    let el6 = arr[5];

    let obj = new Object();

    obj[el1] = el2;
    obj[el3] = el4;
    obj[el5] = el6;

    console.log(obj);
}

// 13. Last Month - FIX
function lastDay(arr){
    let year = arr[2];
    let month = arr[1] - 1;
    let inputDay = arr[0];

    let date = new Date(year, month, inputDay);
    
    date.setDate(1);
    date.setHours(-1);

    let day = date.getDate();

    console.log(day);
}

// 14. Biggest of 3 Numbers
function biggestNum(arr){
    let num1 = arr[0];
    let num2 = arr[1];
    let num3 = arr[2];

    let result = Math.max(num1, num2, num3);

    console.log(result);
}

// 15. Point in Rectangle
function pointRect(arr){
    let x = arr[0];
    let y = arr[1];

    let minX = arr[2];
    let maxX = arr[3];

    let minY = arr[4];
    let maxY = arr[5];

    if(x < minX || x > maxX || y < minY || y > maxY){
        console.log("outside");
    } else{
        console.log("inside");
    }
}

// 16. Odd Numbers 1 To N
function odds(num){
    for(let i = 1;i <= num; i+=2){
        console.log(i);
    }
}

// 17. Triangle of Dollars
function dollars(num){
    for(let row = 1; row<=num; row++){
        let line = '';
        for(let col = 1; col <= row; col++){
            line+='$';
        }
        console.log(line);
    }
}

// 18. Movie Price
function moviePrice(arr){
    let movie = new String(arr[0]);
    let day = new String(arr[1]);

    movie = movie.toLowerCase();
    day = day.toLowerCase();

    if(movie == "the godfather"){
        switch(day){
            case "monday": return 12;
            case "tuesday": return 10;
            case "wednesday": return 15;
            case "thursday": return 12.5;
            case "friday": return 15;
            case "saturday": return 25;
            case "sunday": return 30;

            default : return "error";
        }
    } else if(movie == "schindler's list"){
        switch(day){
            case "monday": return 8.5;
            case "tuesday": return 8.5;
            case "wednesday": return 8.5;
            case "thursday": return 8.5;
            case "friday": return 8.5;
            case "saturday": return 15;
            case "sunday": return 15;

            default : return "error";
        }
    } else if(movie == "casablanca"){
        switch(day){
            case "monday": return 8;
            case "tuesday": return 8;
            case "wednesday": return 8;
            case "thursday": return 8;
            case "friday": return 8;
            case "saturday": return 10;
            case "sunday": return 10;

            default : return "error";
        }
    } else if(movie == "the wizard of oz"){
        switch(day){
            case "monday": return 10;
            case "tuesday": return 10;
            case "wednesday": return 10;
            case "thursday": return 10;
            case "friday": return 10;
            case "saturday": return 15;
            case "sunday": return 15;

            default : return "error";
        }
    } else{
        return "error";
    }
}

// 19. Quadratic Equation
function equation(a, b, c){
    let discriminant = Math.pow(b, 2) - 4 * a * c;

    let x1 = 0;
    let x2 = 0;

    if(discriminant > 0){
        x1 = (-b + Math.sqrt(discriminant)) / (2 * a);
        x2 = (-b - Math.sqrt(discriminant)) / (2 * a);

            console.log(x2);
            console.log(x1);
            
    } else if(discriminant == 0){
        x1 = (-b) / (2 * a);
        console.log(x1);
    } else{
        console.log('No');
    }
}

// 20. Multiplication Table
function multiTable(n){
    let html = "";
    html+="<table border=\"1\">"
    html+="<tr><th>x</th>";

    for(let row = 1; row <= n; row++){
        html+=`<th>${row}</th>`;
    }
    html+="</tr>";

    for(let row = 1; row <= n; row++){
        html+=`<tr><th>${row}</th>`;
        for(let col = 1; col <= n; col++){
            html+=`<td>${row * col}</td>`;
        }
        html+=`</tr>`;
    }

    html+="</table>";

    console.log(html);
}

// 21. Figure of 4 Squares
function fourSquares(n){
    n = +n;

    let rowCount;
    let colCount = (2 * n) - 1;

    if(n % 2 === 0){
        rowCount = n - 1;
    } else{
        rowCount = n;
    }

    let middleRow = Math.ceil(+n / 2);

    for(let row = 1; row <= rowCount; row++){
        if(row === middleRow || row === 1 || row === rowCount){
            console.log("+" + "-".repeat(n - 2) + "+" + "-".repeat(n - 2) + "+");
        }else{
            console.log("|" + " ".repeat(n - 2) + "|" + " ".repeat(n - 2) + "|");
        }
    }
}

// 22. Monthly Calendar
function calendar(arr){
    let inputDay = +arr[0];
    let month = +arr[1];
    let year = +arr[2];

    let date = new Date(year, month, inputDay);

    date.setDate(1);
    date.setHours(-1);

    let day = date.getDate();
    let dayNum = date.getDay();
    
    let result = `<table>
    <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>
    <tr><td class="prev-month">25</td><td class="prev-month">26</td><td class="prev-month">27</td><td class="prev-month">28</td><td class="prev-month">29</td><td class="prev-month">30</td><td>1</td></tr>
    <tr><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td></tr>
    <tr><td>9</td><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td></tr>
    <tr><td>16</td><td>17</td><td>18</td><td>19</td><td>20</td><td>21</td><td>22</td></tr>
    <tr><td>23</td><td class="today">24</td><td>25</td><td>26</td><td>27</td><td>28</td><td>29</td></tr>
    <tr><td>30</td><td>31</td><td class="next-month">1</td><td class="next-month">2</td><td class="next-month">3</td><td class="next-month">4</td><td class="next-month">5</td></tr>
  </table>
  `;


}