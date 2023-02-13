.model small
.data
msg1    db 13,10,'Trying execute hello.exe$'
msg2    db 13,10,'Error$'
msg3    db 13,10,'First terminating. Press any key$'
fn  db 'hello.exe',0   
param   db 10,' bufer.txt',13   

env dw 0            
cmd_of  dw offset param    
cmd_seg dw @data       
fcb1    dd 0           
fcb2    dd 0          
Len dw $-env 
dsize=$-msg1      
 
.stack 256
.code
start:
    mov ah,4ah     
    mov bx,((csize/16)+1)+256/16+((dsize/16)+1)+256/16
    int 21h     
    mov ax,@data    
    mov ds,ax
    mov es,ax
    mov ah,9        
    lea dx,msg1     
    int 21h         
    mov cx,10 ;?????????? ??????? ?????? ????????? 
metka:
    mov ax,4b00h      
    lea dx,fn      
    lea bx,env     
    int 21h         
    loop metka
    jb er           
ex: mov ah,9       
    lea dx,msg3     
    int 21h         
    mov ah,1      
    int 21h
    mov ax,4c00h       
    int 21h
er: mov ah,9        
    lea dx,msg2     
    int 21h         
    jmp ex        
csize=$-start           
end start