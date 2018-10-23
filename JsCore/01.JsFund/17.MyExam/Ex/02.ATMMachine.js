function machine(arr){
    let currentCashInAtm = 0.0;

    let banknotesInAtm = {};

    for (let i = 0; i < arr.length; i++) {
        let lineTokens = arr[i];

        if(lineTokens.length > 2){
            let currentInsert = lineTokens.reduce((acc, curr) =>  acc + curr);
            currentCashInAtm += currentInsert;

            for (let j = 0; j < lineTokens.length; j++) {
                let currentCashInAtmElement = lineTokens[j];

                if(!banknotesInAtm.hasOwnProperty(currentCashInAtmElement)){
                    banknotesInAtm[currentCashInAtmElement] = 0;
                }
                banknotesInAtm[currentCashInAtmElement]++;
            }

            console.log(`Service Report: ${currentInsert}$ inserted. Current balance: ${currentCashInAtm}$.`);

        } else if(lineTokens.length === 2){
            let accountBalance = +lineTokens[0];
            let moneyToWithdraw = +lineTokens[1];

            if(accountBalance < moneyToWithdraw){
                console.log(`Not enough money in your account. Account balance: ${accountBalance}$.`);

            }else if(currentCashInAtm < moneyToWithdraw){
                console.log(`ATM machine is out of order!`);
            } else{
                accountBalance -= moneyToWithdraw;
                currentCashInAtm -= moneyToWithdraw;

                let currentBanknotes = Object.keys(banknotesInAtm).sort((a, b) => b - a);

                let sumToPay = moneyToWithdraw;

                let index = 0;

                while(sumToPay > 0){
                    let banknote = +currentBanknotes[index];

                    if(banknote <= sumToPay){
                        sumToPay -= banknote;
                        banknotesInAtm[banknote]--;
                    }else if(banknote > sumToPay && index + 1 < currentBanknotes.length){
                        index++;
                    }

                }
                console.log(`You get ${moneyToWithdraw}$. Account balance: ${accountBalance}$. Thank you!`);
            }
        } else if(lineTokens.length === 1){
            let seekElement = +lineTokens[0];

            if(banknotesInAtm.hasOwnProperty(seekElement)){
                    console.log(`Service Report: Banknotes from ${seekElement}$: ${banknotesInAtm[seekElement]}.`);
            }else{
                console.log(`Service Report: Banknotes from ${seekElement}$: 0.`);
            }

        }
    }
}

machine([[10, 10, 10, 10], [50, 40], [10]
    ]
);