function uniformDistrib() {
    const N = 100000; // Number of random variates
    const k = 10;     // Number of intervals

    const randomVariates = [];

    // Generate N uniform random variates in [0, 1)
    for (let i = 0; i < N; i++) {
        const variate = Math.random(); // Random number between 0 and 1
        randomVariates.push(variate);
    }

    // Determine the distribution into class intervals
    const intervalCounts = new Array(k).fill(0);

    for (const variate of randomVariates) {
        const intervalIndex = Math.floor(variate * k);
        intervalCounts[intervalIndex]++;
    }

    for (let i = 0; i < k; i++) {
        const lowerBound = i / k;
        const upperBound = (i + 1) / k;
        const count = intervalCounts[i];
        console.log(`[${lowerBound.toFixed(2)} - ${upperBound.toFixed(2)}): ${count}`);
    }
}

uniformDistrib();
