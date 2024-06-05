# Functional Poker

Example of poker logic with functional programming ♠️♣️♥️️♦️️

| Combinação | Exemplo | Descrição | Chance |
|---|---|---|---|
| **Royal Straight Flush** | <span style="color:red">**A♦️**</span>️, <span style="color:red">**K♦️**</span>️, <span style="color:red">**Q♦️**</span>️, <span style="color:red">**J♦️**</span>️, <span style="color:red">**10♦️**</span>️  | Seqüência consecutiva de mesmo naipe, de 10 a ás. | 0,000154% |
| **Straight Flush** | **5♣️**, **6♣️**,️ **7♣️**,️ **8♣️**, **9♣️**  | Seqüência consecutiva de mesmo naipe (que não seja a real, acima). | 0,00139% |
| **Quadra** | **J♣️**, **J♠️**,️ <span style="color:red">**J♦️**</span>️,️ <span style="color:red">**J♥️**</span>️, 2♣️️  | Quatro cartas de mesma face. | 0,02401% |
| **Full House** | **4♣️**, <span style="color:red">**4♦️**</span>️,️ <span style="color:red">**10♦️**</span>️, **10♣️️**, **10♠️**  | Uma trinca e um par. | 0,1441% |
| **Flush** | <span style="color:red">**4♥️**</span>️, <span style="color:red">**7♥️**</span>️,️ <span style="color:red">**8♥️**</span>️, <span style="color:red">**J♥️**</span>️, <span style="color:red">**A♥️**</span>️ | Cartas de mesmo naipe, mas sem formar seqüência consecutiva. | 0,1965% |
| **Straight** | <span style="color:red">**A♥️**</span>️, **2♣️**,️ <span style="color:red">**3♥️**</span>️, <span style="color:red">**4♦️**</span>️, **5♠️**  | Seqüência consecutiva de faces, mas com naipes distintos. | 0,3925% |
| **Trinca** | <span style="color:red">2♦️</span>️, K♣️,️ <span style="color:red">**7♦️**</span>️, **7♣️**, **7♠️**  | Três cartas de faces iguais. | 2,1128% |
| **Dois pares** | <span style="color:red">**8♥️**</span>️,️ <span style="color:red">**8♦️**</span>️, <span style="color:red">**9♥️**</span>️, **9♠️**, <span style="color:red">7♥️</span>️  | Dois pares de cartas. | 4,7539% |
| **Par** | <span style="color:red">10♦️</span>️,️ **K♠️**, <span style="color:red">**K♥️**</span>️, 2♠️, 5♠️  | Duas cartas de mesma face. | 42,2569% |
| **Carta mais alta** | <span style="color:red">6♦️</span>️, <span style="color:red">3♦️</span>️, <span style="color:red">**10♥️**</span>️,️ <span style="color:red">7♦️</span>️, <span style="color:red">2♦️</span>️  | Quando a mão não corresponde a uma das combinações acima. | 50,1177% |
