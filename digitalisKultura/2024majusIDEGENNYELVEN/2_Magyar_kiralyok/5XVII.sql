SELECT COUNT(*) AS KirályokSzáma
FROM hivatal
WHERE hivatal.mettol <=1700 AND hivatal.meddig >= 1601;
