<?php

for ($i = 0; $i < PHP_INT_MAX; $i++) {
    $email = "cartmanqw+{$i}@gmail.com";
    $hash = sha1($email);

    echo "Trying {$email} - {$hash}" . PHP_EOL;

    if (0 === strpos($hash, 'c0ffee')) {
        echo "Email found: {$email}" . PHP_EOL;
        die;
    }
}

echo "Hash not found. Sad..." . PHP_EOL;