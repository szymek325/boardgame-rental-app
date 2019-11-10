import React from 'react';

const Boardgame = (props) => {
    return (
        <tr>
            <td>{props.i + 1}</td>
            <td>{props.boardgame.name}</td>
            <td>{props.boardgame.price}</td>
            <td>{props.boardgame.creationTime}</td>
        </tr>
    )
}

export default Boardgame;