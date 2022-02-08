<?php
# layout.php
require_once('PageTemplate.php');
?>
<!DOCTYPE HTML>
<html>
<head>
    <title><?php if(isset($TPL->PageTitle)) { echo $TPL->PageTitle; } ?></title>
    <?php if(isset($TPL->ContentHead)) { include $TPL->ContentHead; } ?>
</head>
<body>
    <div id="content">
        <?php if(isset($TPL->ContentBody)) { include $TPL->ContentBody; } ?>
    </div>
</body>
</html>