SELECT szinkron.szinesz, szinkron.hang, COUNT(*) AS filmSzam
FROM szinkron
GROUP by szinkron.szinesz, szinkron.hang
HAVING filmSzam >= 3
ORDER by filmSzam DESC