function medicinevalidation(){

var category = document.getElementById('category').value;
if (category === '') {
    
    alert('please enter category');
    document.getElementById('category').focus();
    return false;
} 
var des = document.getElementById('description').value;
if (des === '') {
    
    alert('please enter description');
    document.getElementById('description').focus();
    return false;
} 
return true;
} 