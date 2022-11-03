function getInfo() {
    console.log("TODO...");
    let baseUrl = 'http://localhost:3030/jsonstore/bus/businfo';
    let stopId = document.getElementById('stopId').value;
    let listOfStops = document.getElementById('buses');
    let stopName = document.getElementById('stopName');

    fetch(`${baseUrl}/${stopId}`)
	.then((response) => {
        return response.json();
	})
	.then((data) => {
        let buses = data.buses;
        let name = data.name;

        stopName.textContent = name;
        listOfStops.innerHTML = '';

        for (const bus of Object.keys(buses)) {
            let li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${buses[bus]} minutes`;
            listOfStops.appendChild(li);
        }

	})
	.catch((error) => {
        stopName.textContent = 'Error';
        //listOfStops.innerHTML = '';
    })
}