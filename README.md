# Renk-iyilestirme
5220505051 - Barash Serbest 

  Bu program, bir resmin renk tonlamasını, renk doygunluğunu ve renk dengesini iyileştirmek 
için kullanılır. Algoritmanın genel çalışma mantığı, belirli bir resmi yüklemek, resmin 
renk tonlama, renk doygunluğu ve renk dengesini hesaplamak, hesaplanan değerleri kullanarak 
her pikselin renk değerlerini ayarlamak ve son olarak iyileştirilmiş resmi kaydetmek şeklindedir.

  Program, System ve System.Drawing adlı iki adet C# kütüphanesini kullanır. System kütüphanesi, 
programın temel işlevlerini ve çeşitli işlemler için gereken veri yapılarını içerirken, 
System.Drawing kütüphanesi, programın resim dosyalarıyla çalışabilmesi için gerekli olan sınıfları içerir.

  Program, bir resim dosyasını yüklemek için Bitmap sınıfını kullanır. Resmin her pikselinin 
renk değerlerine erişmek için GetPixel() yöntemi kullanılır. Renk değerlerini ayarlamak için 
SetPixel() yöntemi kullanılır.

  Program, resmin renk tonlamasını iyileştirmek için, resmin ortalama rengini ve en karanlık ve 
en açık renkleri hesaplar. Ardından, her pikselin renk değerlerini, pikselin orijinal renk değeri 
ile ortalama rengin farkını en açık ve en karanlık renk aralığındaki oranla çarpıp ortalama rengi 
ekleyerek yeniden hesaplar. Bu işlem, resmin tonlamasını düzeltir.

  Renk doygunluğu, resmin renklerinin canlılığı veya matlığı ile ilgilidir. Program, her pikselin 
renk değerlerini yeniden hesaplamak için, pikselin orijinal renk değeri ile ortalama rengin farkını 
en açık ve en karanlık renk aralığındaki oranla çarparak yeniden hesaplar. Bu işlem, renk doygunluğunu artırır.

  Renk dengesi, resimdeki renklerin doğru oranını belirler. Program, her pikselin renk değerlerini
yeniden hesaplamak için, en büyük ve en küçük renk arasındaki farkı hesaplar ve ardından pikselin 
renk bileşenlerinin en büyüğü hangisi ise, diğer iki bileşen arasındaki farkı bu bileşenden çıkararak
yeniden hesaplar. Bu işlem, resmin renk dengesini düzeltir.

  Son olarak, iyileştirilmiş resim dosyası, Save() yöntemi kullanılarak kaydedilir.

  Algoritmanın çalışma zamanı, iki döngü içerdiği için giriş resminin boyutuna bağlı olarak değişir. 
İlk döngü, görüntüdeki her piksel için renk doygunluğu iyileştirmesi yapar. İkinci döngü, renk dengesi 
düzeltmesi yapar. Her döngü, resmin genişliği ve yüksekliği boyunca çalışır, bu nedenle toplam çalışma 
zamanı, giriş resminin boyutuna bağlıdır.

  En iyi durumda, giriş resmi çok küçük olduğunda ve sadece birkaç piksel varsa, algoritmanın 
çalışma zamanı çok kısadır.

En kötü durumda, giriş resmi çok büyük olduğunda ve birçok piksel içeriyorsa, algoritmanın çalışma 
zamanı çok uzun olabilir.

Ortalama durumda, algoritmanın çalışma zamanı, giriş resminin boyutuna bağlı olarak değişir.

  Daha net ifade etmek gerekirse, her döngü için çalışma zamanı n giriş resminin boyutu olan O(n^2)'dir. 
İki döngünün toplam çalışma zamanı da O(n^2) olduğundan, toplam çalışma zamanı O(n^2) olacaktır.
