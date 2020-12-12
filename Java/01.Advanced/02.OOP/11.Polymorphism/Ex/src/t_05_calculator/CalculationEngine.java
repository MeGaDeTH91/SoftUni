package t_05_calculator;

import java.util.ArrayDeque;
import java.util.Deque;

public class CalculationEngine {
    private int result;
    private Deque<Integer> currentMemory;
    private Operation currentOperation;

    public CalculationEngine(){
        this.result = 0;
        this.currentMemory = new ArrayDeque<>();
        this.currentOperation = null;
    }

   public void pushNumber(int number) {
        if (this.currentOperation != null) {
            currentOperation.addOperand(number);

            if (currentOperation.isCompleted()) {
                this.result = currentOperation.getResult();
                this.currentOperation = null;
            }
        } else {
            this.result = number;
        }
    }

    public void saveMemory() {
        this.currentMemory.push(this.result);
    }

    public void recallMemory() {
        this.pushNumber(this.currentMemory.pop());
    }

    void pushOperation(Operation operation) {
        if(operation == null){
            return;
        }
        if (operation.isCompleted()) {
            this.pushNumber(operation.getResult());
        } else {
            this.currentOperation = operation;
            this.pushNumber(this.result);
        }
    }

    int getCurrentResult() {
        return this.result;
    }
}
