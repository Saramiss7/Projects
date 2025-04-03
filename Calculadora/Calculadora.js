const $numSigns = [...document.querySelectorAll('.number, .operacion')];
const $clearButton = document.querySelector('.clear');
const $calculateButton = document.querySelector('.equal');
const $input = document.querySelector('#input');

let result = ""
let freeze = ""
$numnegatiu.addEventListener('click', convertnum)
$clearButton.addEventListener('click', clearResult)
$calculateButton.addEventListener('click', calculateResult)

function clearResult(){
    freeze = false;

    result = ""
    $input.value = "0"
}


$numSigns.forEach(($numSign) => {
    $numSign.addEventListener('click', buttonpressed)
})

function buttonpressed(event) {
    if (freeze){
        event.preventDefault()
        return
    }

    const value = event.target.value;

    if ($input.value === "0" && value === ""){
        return;
    }

    if (result.length === 0){
        $input.value = ""
    }

    const operators = ['+','-','*','/'];

    if (operators.includes(result[result.length -1]) && operators.includes(value)){
        $input.value = $input.value.replace(/.$/, value)
        result.valueOf = $input.value.replace(/.$/, value)

        return
    }

    result += value;
    $input.value += value;
}

function calculateResult(){
    try {
        $input.value = eval(result) //comptar
        freeze = true
    } 
    catch (e) {
        $input.value = "ERROR"
        setTimeout( () => {
        if (confirm("Operación erronea"))
        {
            clearResult()}
        }, 0)
    }
}

