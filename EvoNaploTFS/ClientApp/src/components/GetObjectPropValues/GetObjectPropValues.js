import React from 'react';

//a = {
//    'name': "Product",
//    'price': "1000",
//    'description': "Product description",
//    'characteristics': {
//        'performance': '500',
//        'pressure': '180',
//        'engine': '4',
//        'size': '860*730*1300',
//        'weight': '420'
//    }
//}

function GetObjectPropValues(obj) {

    const listItems = obj.map((number) =>
        <li key={number}>
            {number}
        </li>
    );
    return (
        <ul>{listItems}</ul>
    );

    //return (
    //    Object.entries(obj).map(([key, value]) => {
    //        return (
    //            <div>
    //                {key}
    //                {value}
    //            </div>
    //        );
    //    })
    //);
}

export default GetObjectPropValues;