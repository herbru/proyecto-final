pragma solidity ^0.4.0;

contract smart_contract {
    mapping (address => uint) enviosPendientes;


    function enviar (uint cantidad)returns (bool resultado){
        if (this.balance < cantidad) return;
        
        int  = enviosPendientes[msg.sender];
        // Remember to zero the pending refund before
        // sending to prevent re-entrancy attacks
        enviosPendientes[msg.sender] = 0;
        msg.sender.transfer(cantidad); //manda en wei
    }
}