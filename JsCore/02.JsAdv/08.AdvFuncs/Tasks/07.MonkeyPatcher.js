function monkey(action){
    let that = this;

    let obj = (() => {
        function upvote() {that.upvotes++;}
        function downvote() {that.downvotes++;}
        function score(){
            let balance = that['upvotes'] - that['downvotes'];
            let rating = '';

            let obfuscated = that.upvotes + that.downvotes > 50;

            let votesToAdd = Math.ceil(0.25 * Math.max(that.upvotes, that.downvotes));

            if(that.upvotes / (that.upvotes + that.downvotes) > 0.66){
                rating = 'hot';
            } else if((that.upvotes > 100 || that.downvotes > 100) && balance >= 0){
                rating = 'controversial';
            } else if(balance < 0){
                rating = 'unpopular';
            } else {
                rating = 'new';
            }

            if(that.upvotes + that.downvotes < 10){
                rating = 'new';
            }

            if(obfuscated){
                return [that.upvotes + votesToAdd, that.downvotes + votesToAdd, balance, rating];
            } else{
                return [that.upvotes, that.downvotes, balance, rating];
            }
        }
        return {upvote, downvote, score};
    })();
    return obj[action]();
};

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};
monkey.call(post, 'upvote');
monkey.call(post, 'downvote');