function bmi(name, age, mass, height){
    let resultObj = {};
    let index = +mass / Math.pow((+height/100), 2);
    let bmiIndexPrint = Math.round(index);
    let status = '';
    if(index < 18.5){
        status = 'underweight';
    } else if(index < 25){
        status = 'normal';
    } else if(index < 30){
        status = 'overweight';
    } else if(index >= 30){
        status = 'obese';
    }

    resultObj['name'] = name;
    resultObj['personalInfo'] = {}
    resultObj['personalInfo']['age'] = age;
    resultObj['personalInfo']['weight'] = mass;
    resultObj['personalInfo']['height'] = height;
    resultObj['BMI'] = bmiIndexPrint;
    resultObj['status'] = status;
    if(status === 'obese'){
        resultObj['recommendation'] = 'admission required';
    }
    console.log(resultObj);
    return resultObj;
}
//bmi("Peter", 29, 75, 182);
bmi("Honey Boo Boo", 9, 57, 137);