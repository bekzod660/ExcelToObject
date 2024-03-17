function sortTable(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("myTable");
    switching = true;
    // Set the sorting direction to ascending:
    dir = "asc";
    /* Make a loop that will continue until
    no switching has been done: */
    while (switching) {
        // Start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /* Loop through all table rows (except the
        first, which contains table headers): */
        for (i = 1; i < (rows.length - 1); i++) {
            // Start by saying there should be no switching:
            shouldSwitch = false;
            /* Get the two elements you want to compare,
            one from current row and one from the next: */
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /* Check if the two rows should switch place,
            based on the direction, asc or desc: */
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }

    updateIndexNumbers()
}


function updateIndexNumbers() {
    var table = document.getElementById("myTable");
    var rows = table.rows;

    for (var i = 1; i < rows.length; i++) {
        rows[i].getElementsByTagName("TD")[0].innerHTML = i;
    }
}
function Search() {
    // Get the input element by its id
    var searchInput = document.getElementById('searchInput');

    // Get the value of the input element
    var inputValue = searchInput.value;
    let url = new URL(window.location);
    url.searchParams.set("searching", JSON.stringify(inputValue));
    window.location = url.toString();
}

function Paging(pageOrIndex) {
    if (typeof pageOrIndex == "number")    
        paginationMetaData = pageOrIndex;
    console.log(paginationMetaData);
    let url = new URL(window.location);
    url.searchParams.set("pagination", JSON.stringify(paginationMetaData));
    window.location = url.toString();
}
function DeleteEmployeeById(id)
{
    if (window.confirm("Are you sure delete?"))
        window.location = "/delete/" + id;
}
