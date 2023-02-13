.model small
.stack 100h
.data
     filespec db 'file.txt', 0
     strError db 'Error', '$'
     strError1 db 'ErrorRRRR', '$'
     buffer db 22 dup(0)
     kol db 0
     strKol db 5 dup (?), '$' 
     StrEnd = $-1      
     smb db 0Ah
.code 

   
    OpenFileRead PROC    
        mov ah, 3dh             
        mov al, 0   
        lea dx, filespec       
        int 21h
        ret
    OpenFileRead ENDP 

    CloseFile PROC
        mov ah, 3eh            
        int 21h
        ret
    CloseFile ENDP


    SearchStrings PROC
        push ax                                
        push cx
        push dx
        push si
        
        mov al, kol             
        mov dl, smb
        
    Search:
        cmp buffer[si], 0Dh     
        jne notFound
        cmp dl, 0Ah            
        je notFound 
        inc al                  
        
    notFound:
        mov dl, buffer[si]      
        inc si                  
        
        loop Search
        
        mov kol, al              
        mov smb, dl            
        
        pop si                 
        pop dx
        pop cx
        pop ax
        ret
    SearchStrings ENDP 
    
 
    WriteString PROC
        xor ax, ax           
        std                 
        lea di, StrEnd-1 ;     

        mov al, kol            

        mov cx, 10            
    Repeat:
        xor dx, dx            
        div cx                
                   
        xchg ax,dx             
        add al, '0'            
        stosb                  
        xchg ax,dx             
        or  ax,ax             
        jne Repeat  
                                       
        ret
    WriteString ENDP    
        

    start:
        mov ax, @data           
        mov ds, ax
        mov es, ax
        call OpenFileRead     
     
        jc Error1               
        
        mov bx, ax                                           
        
    Read:                      
        mov ah, 3fh
        mov cx, 20             
        lea dx, buffer        
        int 21h
        
        jc Error
        
        cmp cx, ax
        jg Last                 
        
        call SearchStrings
        
        loop Read
        
    Last: 
        cmp ax, 0            
        je Then
        mov cx, ax            
        lea di, buffer
        add di, cx
        push ax
        mov al, 0Dh           
        stosb
        mov al, 0Ah           
        stosb
        add cx, 2              
        pop ax
         
        call SearchStrings 
        
    Then:    
        cmp smb, 0Ah          
        je noAdd
        add kol, 1
    noAdd:    
            
        call CloseFile
        
        call WriteString
        
        lea dx,[di+1]        
        jmp Write
    Error:
        lea dx, strError        
    Error1:
        lea dx, strError1             
    Write:
        mov ah, 09h
        int 21h 
        
            
    Exit:        
        mov ax, 4c00h
        int 21h          
        
        end start