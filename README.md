Aplikacja ma przeliczać opłaty za media (Wode Gaz oraz Prąd).
Rozpoczęcie jest w "Rozpoczęcie apki" w której twożymy mieszkańca a następnie owy mieszkaniec wybiera za co chce zapłacić.
1)wode
2)gaz
3)prąd
aplikacja po wybraniu stosuje switcha do wyboru jaką metode ma zastosować
Następnie w np. WaterMeter aplikacja prosi o nowy stan licznika wody, a następnie odejmuje go od starego.
Po czym wywoływana jest klasa MediaCostAfterMeter która mnoży różnice obliczoną wcześniej przez stałą stawkę za wode.
W klasie ocupan następuje podpisanie pod zmienną wartość WaterCost na wynik uzyskany po przemnożeniu.

Pozdrawiam
