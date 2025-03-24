document.addEventListener('DOMContentLoaded', function () {
    const selector = document.getElementById('selector');
    const sun = document.getElementById('sun');
    const wind = document.getElementById('wind');
    const water = document.getElementById('water');

    function showEnergyNeeded() {
        wind.style.display = 'none';
        water.style.display = 'none';
        sun.style.display = 'none';

        sun.querySelectorAll("input").forEach(input => input.disabled = true);
        wind.querySelectorAll("input").forEach(input => input.disabled = true);
        water.querySelectorAll("input").forEach(input => input.disabled = true);

        const selectedOption = selector.value;

        if (selectedOption) {
            if (selectedOption === '0') {
                sun.style.display = 'block';
                sun.querySelectorAll("input").forEach(input => input.disabled = false);
            } else if (selectedOption === '1') {
                wind.style.display = 'block';
                wind.querySelectorAll("input").forEach(input => input.disabled = false);
            } else if (selectedOption === '2') {
                water.style.display = 'block';
                water.querySelectorAll("input").forEach(input => input.disabled = false);
            }
        }
    }

    selector.addEventListener('change', showEnergyNeeded);

    showEnergyNeeded();
});