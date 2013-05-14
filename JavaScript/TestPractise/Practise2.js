String.prototype.fulltrim=function(){return this.replace(/(?:(?:^|\n)\s+|\s+(?:$|\n))/g,'').replace(/\s+/g,' ');};
function Solve(args) {

    var i,j,  scopeLevel = 0, indexOfOpenBracket,indexOfCloseBracket;
        var lines = args[0]
        var separator = args[1];
        var inputLines = new Array(lines);
        var resultString = "";


   for ( i = 0; i < lines; i++) 
     inputLines[i] = args[i+2].fulltrim;

 for ( i = 0; i < lines; i++) {
    result += printSeperator(separator, scopeLevel);   
    for ( j = 0; j < inputLines[i].length; j++) {
        indexOfOpenBracket = inputLines[i].indexOf('{');
            if (inputLines[i][j] === '{'){
                  resultString += isNextSymBracket(inputLines,i,j,separator,scopeLevel)
                resultString += '{\r\n';
                scopeLevel ++;
                 
            }
            else if (inputLines[i][j] === '}'){
                scopeLevel--;
                resultString += '\r\n';
                resultString += '{\r\n';
            }
               
                else
                    resultString += inputLines[i][j]
      };
    
    }            

}
function isNextSymBracket (inputLines, i, j, separator. scopeLevel) {
     if (inputLines[i][j] !== '{' && inputLines[i][j] !== '}')
       return  '\r\n';
   return printSeperator(separator, scopeLevel);
                    
}
function printSeperator (sep, lvl) {
    var i, result = [];
    for ( i = 0; i < lvl; i++) 
        result.push(sep);
    
    return String(result.join(""));

}
console.log(Solve(["3", "a000"]));