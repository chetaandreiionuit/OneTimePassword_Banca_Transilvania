Salut Denis, pentru functionarea propice a aplicatiei de generare de otp este nevoie de importul bazei pe care am atasat-o in git, otp-urile sunt salvate in DB MSSQL 

Pasi de functionare : 
1. Adaugare de CustomerID
2. Dupa generarea de OTP , luam textul ( care este fromat base64 si il introducem in casuta pentru validare) 
3. Daca este trecut de 30 secunde de cand s-a originat este v-a returna false, in sens contrat ne v-a returna true, orice altceva ne v-a intoarce eroare

Aplicatie este scrisa in C# MVC si stocarea in DB este pe baza framework-ului Entity ( DB First ) 
