class JoinDistribution {
    constructor(matrix, numCols, numRows) {
        this.matrix = matrix;
        this.numCols = numCols;
        this.numRows = numRows;
    }

    printDistribution() {
        const evalDist = this.evalDistribution();

        for (const [key, value] of Object.entries(evalDist)) {
            console.log(`Key = ${key}, Value = ${value}`);
        }
        console.log("\n");
    }

    evalDistribution() {
        const jointDistribution = {};
        const variables = ["Ambitious (0-5)", "Programming Languages"]; // Puoi inserire più variabili

        const varColumns = new Array(variables.length).fill(0);
        for (let i = 0; i < variables.length; i++) {
            for (let j = 0; j < this.numCols; j++) {
                if (this.matrix[0][j] === variables[i]) {
                    varColumns[i] = j;
                    break;
                }
            }
        }

        const valuesMatrix = new Array(varColumns.length);
        let jointValue;

        for (let i = 1; i < this.numRows; i++) {
            valuesMatrix[0] = this.matrix[i][varColumns[0]].toLowerCase().replace(/["\s,]/g, '').split(',');
            for (let k = 1; k < varColumns.length; k++) {
                valuesMatrix[k] = this.matrix[i][varColumns[k]].toLowerCase().replace(/["\s,]/g, '').split(',');
            }

            const combinations = this.cartesianProduct(valuesMatrix);
            for (const combination of combinations) {
                jointValue = combination.join(", ");

                if (!jointDistribution.hasOwnProperty(jointValue)) jointDistribution[jointValue] = 1;
                else jointDistribution[jointValue]++;
            }
        }

        // Ordina e restituisci il risultato
        const sortedJointDistribution = Object.fromEntries(
            Object.entries(jointDistribution).sort((a, b) => b[1] - a[1])
        );

        return sortedJointDistribution;
    }

    cartesianProduct(items) {
        const currentItem = new Array(items.length);
        return this.go(items, currentItem, 0);
    }

    *go(items, currentItem, index) {
        if (index === items.length) {
            yield [...currentItem];
        } else {
            for (const item of items[index]) {
                currentItem[index] = item.toString();
                for (const j of this.go(items, currentItem, index + 1)) {
                    yield [...j];
                }
            }
        }
    }
}

// Esempio di utilizzo
const matrix = [/* Inserire la matrice qui */];
const numCols = /* Numero di colonne */;
const numRows = /* Numero di righe */;

const distribution = new JoinDistribution(matrix, numCols, numRows);
distribution.printDistribution();
