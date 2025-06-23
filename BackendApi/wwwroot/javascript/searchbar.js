const searchbar = document.getElementById('searchbar');
const category = document.getElementById('category');
const tbody = document.getElementById('tbody1');

function Search() {
    const allRows = Array.from(tbody.querySelectorAll('tr'));

    if (searchbar.value.trim().length < 1 || category.value === '0') {
        allRows.forEach(row => row.style.display = '');
        return;
    }

    const searchText = searchbar.value.toLowerCase();
    const catIndex = Number(category.value) - 1;

    allRows.forEach(row => {
        const cell = row.children[catIndex];
        if (!cell) return;

        const cellText = cell.innerText.toLowerCase();
        row.style.display = cellText.includes(searchText) ? '' : 'none';
    });
}

searchbar.addEventListener('input', Search);
category.addEventListener('change', Search);

const observer = new MutationObserver(() => {
    Search();
});

observer.observe(tbody, { childList: true, subtree: true });