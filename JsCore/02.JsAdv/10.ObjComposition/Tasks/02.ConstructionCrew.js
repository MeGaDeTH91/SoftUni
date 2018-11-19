function constructionCrew(worker){
    if(worker['handsShaking']){
        worker['bloodAlcoholLevel'] += +worker['weight'] * 0.1 * +worker['experience'];
        worker['handsShaking'] = false;
    }
    return worker;
}