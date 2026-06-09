# SOLID i C#

solid er en samling av designprinsipper. Kall det retningslinjer for hvordan å designe et system. 
det består av fem prinsipper:

1. Single responsibility Principle:
    Hver klasse skal kunn ha en grunn for å endre tilstand. Det skal kun ha ett ansvar i programmet ditt. 
2. Open Closed Principle:
    Alle klasser skal være åpne for ekstensions, men lukket for modifikasjon. Du kan legge til ny oppførsel til en klasse via en ekstension, men du skal ikke kunne endre oppførselen til klassen direkte. 
3. Liskov Substitution Principle:
    Alle superklasser av en baseklasse, skal også kunne fungere som baseklassen sin. 
4. Interface Segregation Principle:
    En klasse skal ikke tvinges til å implementere deler av en interface den egentlig ikke støtter. 
5. Dependency Inversion Principle:
    Lav-nivå tjenster, skal ikke være avhengig av høynivå tjenester. 