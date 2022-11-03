function solve() {
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule';
    let info = document.querySelector('.info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    let stopId = 'depot';
    let stopName = '';

    async function depart() {
        console.log('Depart TODO...');
        let url = await fetch(`${baseUrl}/${stopId}`);
        let result = await url.json();
        stopName = result.name;

        info.textContent = `Next stop ${stopName}`;

        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {
        console.log('Arrive TODO...');
        info.textContent = `Arriving at ${stopName}`;
        
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();