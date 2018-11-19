function makeCar(car){
    let model = car['model'];
    let power = +car['power'];
    let color = car['color'];
    let carriage = car['carriage'];
    let wheelSize = +car['wheelsize'];
    if(wheelSize % 2 === 0){
        wheelSize--;
    }

    let resultCar = {};
    resultCar['model'] = model;
    
    if(power <= 90){
        resultCar['engine'] = { power: 90, volume: 1800 };
    } else if(power <= 120){
        resultCar['engine'] = { power: 120, volume: 2400 };
    } else if(power <= 200){
        resultCar['engine'] = { power: 200, volume: 3500 };
    }

    resultCar['carriage'] = { type: carriage, color: color };
    resultCar['wheels'] = [wheelSize, wheelSize, wheelSize, wheelSize];
    
    return resultCar;
}

makeCar({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);