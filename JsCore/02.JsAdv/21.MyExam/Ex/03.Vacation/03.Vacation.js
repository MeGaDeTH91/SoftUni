class Vacation {
    constructor(organizer, destination, budget){
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    registerChild(name, grade, budget){
        if(budget < this.budget){
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }
        if(!this.kids.hasOwnProperty(grade)){
            this.kids[grade] = [];
        }
        
        let kidAlreadyExistsThere = false;

        for (let i = 0; i < this.kids[grade].length; i++) {
            let kid = this.kids[grade][i];
            let kidName = kid.split('-')[0];
            if(kidName === name){
                kidAlreadyExistsThere = true;
            }
        }


        if(kidAlreadyExistsThere){
            return `${name} is already in the list for this ${this.destination} vacation.`;
        } else{
            this.kids[grade].push(`${name}-${budget}`);
            return this.kids[grade];
        }
    }

    removeChild(name, grade){
        let childExists = false;

        if(!this.kids.hasOwnProperty(grade)){
            return `We couldn't find ${name} in ${grade} grade.`
        }
        let kidToRemove = "";
        let currentCount = this.numberOfChildren;

        if(currentCount > 0){
            for (let i = 0; i < this.kids[grade].length; i++) {
                let kid = this.kids[grade][i];
                let kidName = kid.split('-')[0];

                if(kidName === name){
                    childExists = true;
                    kidToRemove = kid;
                }
            }
        }

        if(!childExists){
            return `We couldn't find ${name} in ${grade} grade.`
        } else{
            this.kids[grade] = this.kids[grade].filter(x => x !== kidToRemove);
            return this.kids[grade];
        }
    }

    get numberOfChildren(){
        let count = 0;

        let gradeKeys = Object.keys(this.kids);

        if(gradeKeys.length > 0){
            for (let i = 0; i < gradeKeys.length; i++) {
                let gradeKey = gradeKeys[i];

                count += this.kids[gradeKey].length;
            }
        }

        return count;
    }

    toString(){
        let gradeKeys = Object.keys(this.kids);
        gradeKeys = gradeKeys.sort((a, b) => a - b);

        let childrenCount = this.numberOfChildren;

        if(childrenCount > 0){
            let result = `${this.organizer} will take ${childrenCount} children on trip to ${this.destination}\n`;

            for (let i = 0; i < gradeKeys.length; i++) {
                let currentGrade = gradeKeys[i];

                let currentGradeChildren = this.kids[currentGrade];

                if(currentGradeChildren.length > 0){
                    result += `Grade: ${currentGrade}\n`;
                    for (let j = 0; j < currentGradeChildren.length; j++) {

                        let currentGradeChild = currentGradeChildren[j];

                        result += `${j + 1}. ${currentGradeChild}\n`;
                    }
                }
            }
            return result;
        }else{
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`
        }
    }
}
let vacation = new Vacation('Miss Elizabeth', 'Dubai', 2000);

console.log(vacation.registerChild('Gosho', 5, 3000));

console.log(vacation.registerChild('Gosho', 6, 3000));
//vacation.registerChild('Lilly', 6, 1500);
//vacation.registerChild('Pesho', 7, 4000);
//vacation.registerChild('Tanya', 5, 5000);
//vacation.registerChild('Mitko', 10, 5500);
console.log(vacation.removeChild('Gosho', 5));
console.log(vacation.toString());
//console.log(vacation.numberOfChildren);
