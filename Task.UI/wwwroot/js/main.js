Array.prototype.remove = function(item)
{
    let index = this.indexOf(item);
    if (index > -1)
        this.splice(index, 1);
}

function Sort(paramName) {
    ToogleSortParam(sortingMetadata, paramName);
    let url = new URL(window.location);
        url.searchParams.set("sorting", JSON.stringify(sortingMetadata));
        window.location = url.toString();
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

function ToogleSortParam(sortingMetadata, paramName) {
    if (sortingMetadata.asc === (paramName)) {
        sortingMetadata.asc = null;
        sortingMetadata.desc = paramName;
    } else if (sortingMetadata.desc === paramName) {
        sortingMetadata.desc = null;
            sortingMetadata.asc = paramName
    } else sortingMetadata.asc = paramName;
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
    if (window.confirm("Are you sure?"))
        window.location = "/delete/" + id;
}
