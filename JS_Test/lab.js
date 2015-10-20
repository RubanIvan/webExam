/**
 * Created by AdminIvan on 02.10.2015.
 */


function foo(){
    var a=[];
    for(i=0;i<3;i++)
    {
        (function(j){
            a.push(function() {
                console.log(j)
            })
        })(i)
    }
    return a;
}

var x=foo();
x[0]();
x[1]();
x[2]();


//function setupCmp(x){
//    var baseNumber=x;
//    return function(y){
//        if(x>y)return 1;
//        if(x<y)return -1;
//        return 0;
//    }
//}
//
//var Comparer=setupCmp(10);
//console.log(Comparer(1) );
//console.log(Comparer(100) );
//console.log(Comparer(10) );
//
//var Comparer=setupCmp(100);
//console.log(Comparer(1) );
//console.log(Comparer(100) );
//console.log(Comparer(10) );


